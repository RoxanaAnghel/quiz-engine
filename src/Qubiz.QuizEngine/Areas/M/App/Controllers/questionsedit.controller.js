(function () {
    'use strict'
    angular
        .module('quizEngineMaterial')
        .controller('QuestionEditController', QuestionEditController)

    QuestionEditController.$inject = ['sectionsDataService', 'questionData', '$routeParams', '$location'];

    function QuestionEditController(sectionsDataService, questionData, $routeParams, $location) {
        var vm = this;

        vm.resetFields = resetFields;
        vm.saveEdit = saveEdit;
        vm.cancelEdit = cancelEdit;

        sectionsDataService.getAllSections().then(function (result) {
            vm.Sections = result.data;
        });

        questionData.getQuestionByID($routeParams.id).then(function (result) {
            vm.originalQuestion = result.data;
            resetFields();
        });

        function resetFields(){
            vm.editedQuestion = angular.copy(vm.originalQuestion);
        }

        function saveEdit() {
            questionData.updateQuestion(vm.editedQuestion);
            $location.path('/questions');
        }

        function cancelEdit() {
            $location.path('/questions');
        }

    }
})();