"use strict";

let app;

$(function () {
    app = new Vue({
        el: "#app",
        data: {
            teams: [],
            drivers: [],
            countries: [],
            circuits: [],
            races: []
        }
    });
});

function loadDrivers() {
    sendRequest("/Drivers", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = data;
        app.circuits = [];
        app.races = [];
    });
}

function loadTeams() {
    sendRequest("/Teams", "get", data => {
        app.teams = data;
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
    });
}

function loadCountries() {
    sendRequest("/Countries", "get", data => {
        app.teams = [];
        app.countries = data;
        app.drivers = [];
        app.circuits = [];
        app.races = [];
    });
}

function loadCircuits() {
    sendRequest("/Circuits", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = data;
        app.races = [];
    });
}

function loadRaces() {
    sendRequest("/Races", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = data;
    });
    
}

function sendRequest(parameters, method, callback) {
    let _richiesta = $.ajax({
        url: "api" + parameters,
        type: method.toUpperCase(),
        data: "",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        timeout: 5000
    });

    _richiesta.done(callback);
    _richiesta.fail(error);
}

function error(jqXHR, testStatus, strError) {
    if (jqXHR.status === 0)
        alert("server timeout");
    else if (jqXHR.status === 200)
        alert("Formato dei dati non corretto : " + jqXHR.responseText);
    else
        alert("Server Error: " + jqXHR.status + " - " + jqXHR.responseText);
};