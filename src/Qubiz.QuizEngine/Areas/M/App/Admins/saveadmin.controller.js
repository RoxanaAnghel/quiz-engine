(function () {
    'use strict';

    angular
       .module('quizEngineMaterial')
       .controller('SaveAdminController', SaveAdminController);

    SaveAdminController.$inject = ['adminsService', '$location', '$mdDialog', '$routeParams'];

    function SaveAdminController(adminsService, location, mdDialog, $routeParams) {

        var vm = this;
        vm.admin = undefined;
        vm.saveText = undefined;
        vm.saveType = true;

        var originalAdmin;

        vm.save = save;
        vm.reset = reset;

        adminsService.getById($routeParams.id)
            .then(function (result) {
                vm.admin = result.data;
                if (vm.admin != null) {
                    vm.saveType = false;
                    originalAdmin = vm.admin.Name;
                    vm.saveText = "Edit Admin";
                }
                else {
                    vm.admin = {};
                    vm.admin.ID = $routeParams.id;
                    vm.saveText = "Add Admin";
                }
            });

        function save() {
            if (vm.admin.Name == "") {
                mdDialog.show(mdDialog
                    .alert()
                    .title('Error')
                    .textContent("Empty Name")
                    .ok('Ok!'));
                return;
            }
            if (vm.saveType)
                addAdmin();
            else
                editAdmin();
        }

        function addAdmin() {
            adminsService.addAdmin(vm.admin)
                .then(function () {
                    location.path('/administrators');
                })
                .catch(function (result) {
                    mdDialog.show(mdDialog
                   .alert()
                   .title('Error')
                   .textContent(result.data.Message)
                   .ok('Ok!'));
                });
        }

        function editAdmin() {
            adminsService.editAdmin(vm.admin)
                .then(function () {
                    location.path('/administrators');
                })
                .catch(function (result) {
                    mdDialog.show(mdDialog
                        .alert()
                        .title('Error')
                        .textContent(result.data.Message)
                        .ok('Ok!'));
                });
        }

        function reset() {
            if (vm.saveType) {
                vm.admin.Name = "";
            }
            else {
                vm.admin.Name = originalAdmin;
            }
        }
    }
})();