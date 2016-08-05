﻿(function () {
    'use strict'
    angular.module('quizEngineMaterial').controller('QuestionListController', QuestionListController)

    QuestionListController.$inject = ['questionData'];

    function QuestionListController(questionData) {
        var vm = this;

        vm.nextPage = nextPage;
        vm.prevPage = prevPage;
        vm.updatePage = updatePage;

        vm.pageNumber = 0;

        getQuestions();

        function getQuestions() {
            questionData.filteredQuestion({ pagenumber: vm.pageNumber }).$promise.then(function (result) {
                vm.Questions = result;
                vm.maxPages = Math.ceil(vm.Questions.TotalCount / 20) - 1;
            });
        }

        function nextPage() {
            vm.pageNumber++;
            updatePage();
        }
        function prevPage() {
            vm.pageNumber--;
            updatePage();
        }
        function updatePage() {
            if(isNaN(vm.pageNumber)){ vm.pageNumber = 0 }
            if (vm.pageNumber > vm.maxPages) { vm.pageNumber = vm.maxPages; }
            if (vm.pageNumber < 0) { vm.pageNumber = 0; }
            getQuestions();
        }

    }
})();