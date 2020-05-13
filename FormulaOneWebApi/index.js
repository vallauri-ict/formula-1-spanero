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
            races: [],
            racesScores: []
        }
    });
});

function singleCircuit() {
    sendRequest("/circuits/" + $('#txtCircuit').val(), "get", data => {

        app.teams = [];
        app.countries = [];
        app.drivers = [];
        //[data] crea un vettore di una pos per far partire il "trigger" della tabella 
        app.circuits = [data];
        app.races = [];
        app.racesScores = [];
        console.log(data);
        console.log(app.circuits);
    });
}

function singleTeam() {
    sendRequest("/teams/" + $('#txtTeam').val(), "get", data => {
        app.teams = [data];
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
    });
}

function singleDriver() {
    sendRequest("/drivers/" + $('#txtDriver').val(), "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [data]; 
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
    });
}

function singleCountry() {
    sendRequest("/countries/" + $('#txtCountry').val(), "get", data => {
        app.teams = [];
        app.countries = [data];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
    });
}

function singleRace() {
    sendRequest("/races/" + $('#txtRace').val(), "get", data => {

        app.teams = [];
        app.countries = [];
        app.drivers = [];       
        app.circuits = [];
        app.races = [data];
        app.racesScores = [];
    });
}

function singleRaceScore() {
    sendRequest("/racesScores/" + $('#txtRaceScore').val(), "get", data => {

        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = data;
    });
}

function loadDrivers() {
    sendRequest("/drivers", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = data;
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
    });
}

function loadTeams() {
    sendRequest("/teams", "get", data => {
        app.teams = data;
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
        console.log(data);
    });
}

function loadCountries() {
    sendRequest("/countries", "get", data => {
        app.teams = [];
        app.countries = data;
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = [];
    });
}

function loadCircuits() {
    sendRequest("/circuits", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = data;
        app.races = [];
        app.racesScores = [];
    });
}

function loadRaces() {
    sendRequest("/races", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = data;
        app.racesScores = [];
    });
}

function loadRacesScores() {
    sendRequest("/racesScores", "get", data => {
        app.teams = [];
        app.countries = [];
        app.drivers = [];
        app.circuits = [];
        app.races = [];
        app.racesScores = data;
        console.log(data);
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