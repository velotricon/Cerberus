var LightComboBoxDirective = function () {
    return {
        restrict: 'E',
        templateUrl: 'DirectiveTemplates/LightComboBox',
        replace: true,
        link: LightComboLinkFunction,
        controller: LightComboController,
        scope: {
            model: '=',
            combo: '@',
            selected: '='
        }
    }//end-of-return
}//end-of-LightComboBoxDirective

function LightComboLinkFunction(scope, element, attr, ctrl, transcludeFn) {

}//end-of-LightComboLinkFunction

function LightComboController($scope, $element, $attrs, $transclude, $http) {

    $scope.PrepareData = function () {
        //nic tu na razie
    }

    $scope.GetCombo = function () {
        $http.get('api/ComboBoxApi/GetLigtComboBox', {
            params: { ComboName: $scope.combo }
        }).error(function (data, status, headers, config) {
            alert('error ' + status);
        }).success(function (data, status, headers, config) {
            $scope.model = angular.fromJson(data);
            $scope.PrepareData();
            //alert('success ' + status);
        });//end-of-$http.get
    }

    $scope.GetCombo();

}//end-of-LightComboController

