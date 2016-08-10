(function () {
    'use strict'
    angular
        .module('quizEngineMaterial')
        .controller('QuestionAddController', QuestionAddController)

    QuestionAddController.$inject = ['questionData'];

    function QuestionAddController(questionData) {
        var vm = this;
    }
})();