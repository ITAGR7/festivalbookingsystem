// fullcalender.js - export function for import in razor via the OnAfterRenderAsync method
//https://fullcalendar.io/docs/initialize-globals

//making the function available for import in razor
export function initializeCalendar(events) {
    //console logging to check that the shifts are correctly being passed to the function
    console.log(events);
    
    //grabbing the calendar element from the DOM and assigning it to a variable
    var calendarEl = document.getElementById('calendar');
    
    //creating a new calendar object and assigning it to a variable, giving it the calendar element and the events as parameters
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: events,
        selectable: true,
    });
    
    //rendering the calendar
    calendar.render();
}



