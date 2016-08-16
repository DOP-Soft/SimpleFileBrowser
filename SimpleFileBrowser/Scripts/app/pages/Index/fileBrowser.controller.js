
(function (angular) {
    angular.module("fileBrowserModule")
            .controller("fileBrowserCtrl", fileBrowserCtrl);
    fileBrowserCtrl.$inject = ['$scope', 'fileBrowserService'];

    function fileBrowserCtrl($scope, fileBrowserService) {
        var vm = this;

        vm.filesCountInfo = {
            lessThan10Mb: 0,
            between10MbAnd50Mb: 0,
            moreThan100Mb: 0
        };
        vm.currentDirFiles = [];
        vm.currentDir = "";
        vm.parentDir = null;

        vm.isLoading = true;

        activate();

        function activate() {
            fileBrowserService.getFiles()
            .then(function (response) {
                vm.parentDir = response.data.ParentDir;
                vm.currentDir = response.data.CurrentDir;
                vm.currentDirFiles = response.data.Files;
                vm.filesCountInfo.lessThan10Mb = response.data.Less5Mb;
                vm.filesCountInfo.between10MbAnd50Mb = response.data.From10To50Mb;
                vm.filesCountInfo.moreThan100Mb = response.data.MoreThan100Mb;

                vm.isLoading = false;
            });
        }

        vm.getFilesByPath = function (path) {
            fileBrowserService.getFilesByPath(path)
            .then(function (response) {
                vm.parentDir = response.data.ParentDir;
                vm.currentDir = response.data.CurrentDir;
                vm.currentDirFiles = response.data.Files;
                vm.filesCountInfo.lessThan10Mb = response.data.Less5Mb;
                vm.filesCountInfo.between10MbAnd50Mb = response.data.From10To50Mb;
                vm.filesCountInfo.moreThan100Mb = response.data.MoreThan100Mb;

                vm.isLoading = false;
            });
        };
    };

})(angular);