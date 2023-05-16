// fullcalender.js - export function for import in razor via the OnAfterRenderAsync method
//https://fullcalendar.io/docs/initialize-globals

//making the function available for import in razor
export function initializeCalendar(events, dotNetReference) {
    //console logging to check that the shifts are correctly being passed to the function
    console.log(events);
    
    //grabbing the calendar element from the DOM and assigning it to a variable
    var calendarEl = document.getElementById('calendar');
    
    //creating a new calendar object and assigning it to a variable, giving it the calendar element and the events as parameters
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: events,
        selectable: true,
        selectMirror: true,
        eventMouseEnter: function( mouseEnterInfo ) { 
            //Color needs to change to a lighter color when mouse enters
            mouseEnterInfo.el.style.backgroundColor = 'lightblue';
            //change mouse pointer to a hand
            mouseEnterInfo.el.style.cursor = 'pointer';
        },
        eventMouseLeave: function( mouseLeaveInfo ) {
            //return normal color before mouse enter
            mouseLeaveInfo.el.style.backgroundColor = '';
        },
        eventClick: function(info) {
            // Use the dotNetReference to invoke the C# method
            dotNetReference.invokeMethodAsync('ShiftsDialog', info.event.title,
                info.event.extendedProps.description,
                info.event.extendedProps.capacity,
                info.event.duration,
                info.event.start,
                info.event.end);
        },

    });
    
    //rendering the calendar
    calendar.render();
}



