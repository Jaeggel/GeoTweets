//Obtención de la lista de los laboratorios con su respectiva ubicación para su posterior cargar en el mapa.
function getMapDataHome(url) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            initMap(data);
        },
        error: function (response) {
            console.log("No se pudo visualizar el mapa"+response);
        }
    });
}
//Método para cargar el mapa con la ubicación de todos los laboratorios (Ubicación Global País)
function initMap(data) {
    var markerUrl = "http://localhost/ProyectoGISTweets/logo.ico";
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 2,
        center: new google.maps.LatLng(0,0),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    
    var infowindow = new google.maps.InfoWindow();
    var marker, i;
    var markers = [];
    var bouncingMarker = null;
    clearMarkersHome();
    if (data !== null) {
        for (i = 0; i < data.length; i++) {
            addMarkerWithTimeoutHome(data[i], i * 75);//200
        }
    }
    //Método para configurar marcador de ubicación
    function addMarkerWithTimeoutHome(position, timeout) {
        window.setTimeout(function () {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(position.Latitud, position.Longitud),
                map: map,
                animation: google.maps.Animation.DROP,
                icon: markerUrl
            });
            google.maps.event.addListener(marker, 'click', clickListener);
            markers.push(marker);
            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent("<p><b>Tweet: </b><i align='left'>\"" + position.Text + "</i>\"<p/><hr/><p>" + "<b>Ciudad: </b>" + position.Location + "</p>" + "<b>Usuario: </b>" + position.User + "</a>" + "</p><p>" + "<b>Latitud: </b>" + position.Latitud + "</p><p>" + "<b>Longitud: </b>" + position.Longitud + "</p>" + "<b>Fecha: </b>" + position.Time + "</p>" + "<b>Id: </b>" + position.Id + "</p>" + "<b>Screen Name: </b>" + position.ScreenName + "</p>");
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }, timeout);
    }
    //Método para configurar animación del marcador
    var clickListener = function () {
        if (bouncingMarker)
            bouncingMarker.setAnimation(null);
        if (bouncingMarker !== this) {
            this.setAnimation(google.maps.Animation.BOUNCE);
            bouncingMarker = this;
        } else
            bouncingMarker = null;
    }
    //Método para limpiar todos los marcadores antes de ser mostrados
    function clearMarkersHome() {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }
        markers = [];
    }
}
//Método para mostrar alertas notify
function showNotify(title, message, messagetype) {
    var icon;
    if (messagetype === 'danger') {
        icon = "glyphicon glyphicon-remove-sign";
        title = '<b>' + title + '</b><br/>'
    } else {
        icon = "glyphicon glyphicon-ok-sign";
        title = '<b>' + title + '</b><br/>'
    }
    $.notify({
        icon: icon,
        title: title,
        message: message,
    }, {
        animate: {
            enter: 'animated fadeInRight',
            exit: 'animated fadeOutRight'
        },
        type: messagetype
    });
}