
$(document).ready(function () {

    $('#calendar').fullCalendar({
        locale: 'es', // TRADUCCION
        firstDay: 1, //EMPEZAR EL DIA EN LUNES
        eventLimit: true, // CREA EL MORE CUANDO HAY MUCHOS EVENTOS EN UN MISMO DIA
        selectable: true, //AL SELECCIONAR SE MARQUE EL DÍA
        navLinks: true,
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'Hoy',
            month: 'Mes',
            week: 'Semana',
            day: 'Día'
        },

        //CLICK EN UN EVENTO
        eventClick: function (eventObj) {
            if (eventObj.url) {
                alert(
                    'LE HAS DADO AL EVENTO: ' + eventObj.title + '.\n' +
                    'Will open ' + eventObj.url + ' in a new tab'
                );
                window.open(eventObj.url);
                return false; // prevents browser from following link in current tab.
            } else {
                alert('Clicked ' + eventObj.title);
            }
        },

        //EVENTOS CREADOS
        events: [
            {
                id: '1',
                resourceId: 'a',
                title: 'event1',
                start: '2019-02-01'
            },
            {
                title: 'event2',
                start: '2019-02-05',
                end: '2019-02-07'
            },
            {
                title: 'event3',
                start: '2019-02-09 12:30:00',
                allDay: false // will make the time show
            },
            {
                title: 'event4',
                start: '2019-02-05',
                end: '2019-02-07'
            },
            {
                title: 'event5',
                start: '2019-02-05',
                end: '2019-02-07'
            },
            {
                title: 'event6',
                start: '2019-02-05',
                end: '2019-02-07'
            }
        ],
        editable: true //PODER MOVER LOS EVENTOS (DRAG AND DROP)
        
         //CLICK EN UN DÍA
            /* dayClick: function (date, jsEvent, view) {

                 alert('Clicked on: ' + date.format());

               //  alert('Date: ' + date.format());
               //  alert('Resource ID: ' + resourceObj.id);
               //  $(this).css('background-color', 'red'); //Colorear dia seleccionado
                //alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
                // alert('Current view: ' + view.name);
             },*/

        /*
        events: function (start, end, timezone, callback) {
            $.ajax({
                url: '/Home/GetCalendarData',
                type: "GET",
                dataType: "JSON",

                success: function (result) {
                    var events = [];

                    $.each(result, function (i, data) {
                        events.push(
                            {
                                title: data.Title,
                                description: data.Desc,
                                start: moment(data.Start_Date).format('YYYY-MM-DD'),
                                end: moment(data.End_Date).format('YYYY-MM-DD'),
                                backgroundColor: "#9501fc",
                                borderColor: "#fc0101"
                            });
                    });

                    callback(events);
                }
            });
        },
        eventRender: function (event, element) {
            element.qtip(
                {
                    content: event.description
                });
        },*/
    });
});