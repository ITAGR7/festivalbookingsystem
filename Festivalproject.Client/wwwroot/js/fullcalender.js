// fullcalender.js - export function for import in razor via the OnAfterRenderAsync method
//https://fullcalendar.io/docs/initialize-globals

//making the function available for import in razor
export function initializeCalendar(events, dotNetReference) {
    
    //console logging to check that the shifts are correctly being passed to the function
    console.log(events);

    const toiletvagtColor = '#CFE4C8';
    const barvagtColor = '#AEBAD6';
    //modifying the events data to add color based on type
    events = events.map(event => {
        if (event.type === "toiletvagt") {
            return {...event, color: toiletvagtColor};
        } else if (event.type === "barvagt") {
            return {...event, color: barvagtColor};
        } else {
            return event;
        }
    });

    console.log("Modified events: ", events); // Log the modified events
    console.log("Sample event: ", events[0]); // Log the first event

    //grabbing the calendar element from the DOM and assigning it to a variable
    var calendarEl = document.getElementById('calendar');


    //creating a new calendar object and assigning it to a variable, giving it the calendar element and the events as parameters
    var calendar = new FullCalendar.Calendar(calendarEl, {
        events: events,
        initialDate: '2023-06-01',
        timezone: 'local',
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
            // Change the color and cursor
            mouseEnterInfo.el.style.backgroundColor = '#FFF2EB';
            mouseEnterInfo.el.style.cursor = 'pointer';
        },
        eventMouseLeave: function (mouseLeaveInfo) {
            // Restore the original color
            mouseLeaveInfo.el.style.backgroundColor = mouseLeaveInfo.el.dataset.originalColor;
        },
        eventClick: function (info) {
            console.log('ShiftsDialog - shiftArea (JS):', info.event.extendedProps.shiftId);

            // Use the dotNetReference to invoke the C# method
            dotNetReference.invokeMethodAsync('ShiftsDialog',
                info.event.extendedProps.type,
                info.event.extendedProps.shiftId,
                info.event.title,
                info.event.start,
                info.event.end,
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

    //rendering the calendar
    calendar.render();
}



