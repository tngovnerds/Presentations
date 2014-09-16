var myApp = angular.module('myApp', []);

myApp.constant('BASEURL', 'http://localhost:23357/api/person');

myApp.factory('PersonService', ['$http', 'BASEURL', PersonService]);

myApp.controller('PersonController', ['PersonService', PersonController]);

function PersonController(personService) {
    var self = this;

    this.personList = [];
    this.selectedPerson = [];

    this.selectPerson = function(id) {
        
        personService.getPerson(id).then(function (result) {            
            self.selectedPerson = result.data;
            
        });
    };

    this.savePerson = function(person) {
        personService.savePerson(person).then(function(result) {
            self.selectedPerson = result.data[0];
            getList();
        });
    };

    this.createPerson = function() {
        //blah, out of time.        
        this.selectedPerson = { FirstName: "", LastName: "", Addresses:[] };
    };

    this.addAddress = function() {
        this.selectedPerson.Addresses.push({ Street: "", City: "", State: "", ZipCode: "" });
    };
    
    //initial load
    getList();

    function getList() {
        personService.getPeople().then(function(result) {
            self.personList = result.data;
        });
    }
}

function PersonService($http, baseUrl) {
    return {
        getPeople: getPeople,
        getPerson: getPerson,
        savePerson: savePerson
    };

    function getPeople() {
       
        var options = {
            url: baseUrl,
            method: 'GET',
            responseType: 'json'
        };
        return $http(options);
    }

    function getPerson(id) {
        var options = {
            url: baseUrl,
            method: 'GET',
            responseType: 'json',
            params: {id: id}
        };
        return $http(options);
    }

    function savePerson(person) {
        var options = {
            url: baseUrl,
            method: 'POST',
            responseType: 'json',
            data: { person: person }
        };
        return $http.post(baseUrl, person);
    }
}
