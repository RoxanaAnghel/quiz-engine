(function () {
    'use strict'

    angular
        .module('quizEngineMaterial', ['ngRoute', 'ngAnimate', 'ngAria', 'ngMaterial'])
        .config(function ($routeProvider) {
            $routeProvider
                .when("/tests", {
                    templateUrl: "Template/Test"
                })
                .when("/exams", {
                    templateUrl: "Template/Exams"
                })
                .when("/questions", {
					templateUrl: "Template/Questions",
					controller: "QuestionListController",
					controllerAs: "questionCtrl"
                })
                .when("/editquestion/:id", {
					templateUrl: "Template/QuestionsEdit",
					controller: "QuestionEditController",
					controllerAs: "questionCtrl"
                })
                .when("/addquestion", {
                    templateUrl: "Template/QuestionsAdd",
                    controller: "QuestionAddController",
                    controllerAs: "questionCtrl"
                    })
                .when("/sections", {
                    templateUrl: "Template/Sections",
                    controller: "SectionsController",
                    controllerAs : "SectionsCtrl"
                })
                .when("/administrators", {
                	templateUrl: "Template/Administrators",
                	controller: "AdminsController",
                	controllerAs: "AdminCtrl"
                })
                .when('/addadmin', {
                	templateUrl: "Template/AddAdmin",
                	controller: "AddAdminController",
                	controllerAs: "AddAdminCtrl"
                })
                .when('/editadmin/:id',
                {
                	templateUrl: "Template/EditAdmin",
                	controller: "EditAdminController",
                	controllerAs: "EditCtrl"
                })
		        .otherwise({ redirectTo: "/tests" });
        });
})();