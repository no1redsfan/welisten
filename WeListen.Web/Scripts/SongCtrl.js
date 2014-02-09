"use strict";

function SongCtrl($http) {
    alert("in songctrl");
    //$scope.songs = [{ Title: 'yay title' }];
    
    //$http.get('/someUrl').success(successCallback);
    
    $http({ method: 'GET', url: '/Songs/GetSongs' }).
success(function (data) {
    alert('success!' + data);
}).
error(function (data, status, headers, config) {
    alert("data" + data + "status" + status);
});
    
}

