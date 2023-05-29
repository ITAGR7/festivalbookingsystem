let calendar; // Make the calendar object accessible in all functions

// hardcoding color map globally so it can be accessed in all functions
const colorMap = {
    "barvagt": '#6D9EEB',
    "toiletvagt": '#D4BF77',
    "indgangvagt": '#7BB661',
    "parkeringsvagt": '#E67399',
    "køkkenvagt": '#DB843D',
    "sikkerhedsvagt": '#A47AE2'
};

// calendar being initialized with the given events
export function initializeCalendar(inputEvents, dotNetReference) {
    console.log("initializeCalendar called");
    // Events are the inputEvents, but with a color added to each event, based on the type of event
    const events = inputEvents.map(event => {
        const color = colorMap[event.type];
        if (color) {
            return {...event, color};
        } else {
            // If the event type is not in the colorMap, then the event is returned without a color added
            return event;
        }
    });
    console.log("Input Events: ", inputEvents);
    console.log("Events with colors: ", events);

    // If the calendar is already initialized, remove old events before adding new ones
    // If the calendar is already initialized, remove old events before adding new ones
    if (calendar) {
        console.log("Calendar already initialized. Updating events.");
        calendar.getEventSources().forEach(function(eventSource) {
            eventSource.remove();
        });
        calendar.addEventSource(events);
        console.log("Events updated.");
        calendar.render();
        console.log("Calendar re-rendered.");
    } else {
        console.log("Initializing new calendar");
        // Declaring the calenderEL variable, and setting it to the element (div) with the id "calendar"
        const calendarEl = document.getElementById('calendar');

        // Declaring the calendar variable, and setting it to a new FullCalendar.Calendar
        calendar = new FullCalendar.Calendar(calendarEl, {
            // Different settings for the calendar -> https://fullcalendar.io/docs
            events: events,
            initialDate: '2023-06-01',
            timeZone: 'local',
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

                // Use the dotNetReference to invoke the C# method with the given parameters
                dotNetReference.invokeMethodAsync('ShiftsDialog',
                    
                    //extendedProps being used to get the properties of the event that are not "normal"
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

        // Lastly rendering the calendar
        calendar.render();
        console.log("Calendar initialized and rendered.");
    }
}
