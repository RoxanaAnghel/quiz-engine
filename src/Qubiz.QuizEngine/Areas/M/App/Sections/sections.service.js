﻿(function () {
    'use strict'
    angular
        .module('quizEngineMaterial')
        .service('SectionsDataService', SectionsDataService)

    SectionsDataService.$inject = ['$http','$q'];

    function SectionsDataService($http,$q) {

        this.getAllSections = getAllSections;
        this.deleteSection = deleteSection;
         
        function getAllSections() {
            return $http({
                method: 'GET',
                url: 'M/api/Section'
            })
                .then(getSectionsSuccess)
                .catch(errorCallBack)
        }

        function errorCallBack(response) {
            return $q.reject('HTTP status : ' + response.status + ' ' + response.statusText);
        }

        function getSectionsSuccess(response) {
            return response.data;
        }

        function deleteSection(id) {
            return $http.delete('M/api/sections/' + id)
                .then(deletedSuccess)
                .catch(errorCallBack);
        }

        function deletedSuccess(response) {
            return console.log("Section Deleted !");
        }
    }

})();