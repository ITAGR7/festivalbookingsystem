let calendar; // Make the calendar object accessible in all functions
let events; // Make events globally accessible

// Define the color mapping globally so it can be accessed in all functions
const colorMap = {
    "barvagt": '#6D9EEB',
    "toiletvagt": '#D4BF77',
    "indgangvagt": '#7BB661',
    "parkeringsvagt": '#E67399',
    "køkkenvagt": '#DB843D',
    "sikkerhedsvagt": '#A47AE2'
};

// Initialize the calendar with the given events
export function initializeCalendar(inputEvents, dotNetReference) {
    // Save the input events in the global events variable
    events = inputEvents.map(event => {
        const color = colorMap[event.type];
        if (color) {
            return {...event, color};
        } else {
            return event;
        }
    });

    console.log("Events: ", events); // Log the events to the console

    var calendarEl = document.getElementById('calendar');
    console.log("Events: ", events); // Log the events to the console
    calendar = new FullCalendar.Calendar(calendarEl, {
        events: events,
        initialDate: '2023-06-01',
        timeZone: 'UTC',
        locale: 'da',
        dayMaxEvents: true,
        initialView: 'dayGridMonth',
        weekNumbers: true,
        eventDisplay: 'block',
        headerToolbar: {
            left: 'title',
            center: '',
            right: 'prev,next today'
        },
        buttonText: {
            today: 'I dag',
            month: 'Måned',
            week: 'Uge',
            day: 'Dag',
        },
        weekText: 'Uge ',
        eventMouseEnter: function (mouseEnterInfo) {
            // Store the original color in a data attribute
            mouseEnterInfo.el.dataset.originalColor = mouseEnterInfo.el.style.backgroundColor;
            // Change the color to something a bit brighter and cursor
            mouseEnterInfo.el.style.filter = 'brightness(120%)';
            mouseEnterInfo.el.style.cursor = 'pointer';
        },
        eventMouseLeave: function (mouseLeaveInfo) {
            // Restore the original color
            mouseLeaveInfo.el.style.filter = 'none';
        },
        eventClick: function (info) {
            console.log('ShiftsDialog - shiftEnd (JS):', info.event.end);

            // Use the dotNetReference to invoke the C# method
            dotNetReference.invokeMethodAsync('ShiftsDialog',
                info.event.extendedProps.type,
                info.event.extendedProps.shiftId,
                info.event.title,
                info.event.start.toISOString(), // Convert the Date to a string in ISO 8601 format
                info.event.end.toISOString(),
                info.event.extendedProps.description,
                info.event.extendedProps.area,
                info.event.extendedProps._duration,
                info.event.extendedProps._userId,
            );
        },

        eventTimeFormat: { // like '14:30:00'
            hour: '2-digit',
            minute: '2-digit',
            meridiem: false,
            hour12: false,
        },
    });

    console.log("Calendar initialized"); // Log that the calendar has been initialized

    //rendering the calendar
    calendar.render();
    
}
// Update the events
export function updateEvents(inputEvents) {
    events = inputEvents.map(event => {
        const color = colorMap[event.type];
        if (color) {
            return {...event, color};
        } else {
            return event;
        }
    });

    console.log("Updated Events After Tilmeldvagt: ", events); // Log the events to the console
}

// Refresh the calendar
export function refreshCalender () {
    calendar.removeAllEvents();
    calendar.addEventSource(events);
    calendar.render();
}