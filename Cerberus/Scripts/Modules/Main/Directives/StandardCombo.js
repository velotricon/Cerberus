function StandardComboDirective() {
    return {
        restrict: 'E',
        templateUrl: 'Template/StandardCombo',
        replace: true,
        link: StandardComboLinkFunction,
        controller: StandardComboController,
        scope: {
            model: '='
        }
    }//end-of-return
}//end-of-StandardCombo

function StandardComboLinkFunction(scope, element, attr, ctrl, transcludeFn) {

}//end-of-StandardComboLinkFunction

function StandardComboController($scope, $element, $attrs, $transclude) {

    $scope.PrepareData = function () {
        //nic tu na razie
    }

    $scope.GetCombo = function () {
        $http.get('api/DataProviderAPI/GetGridView', {
            params: { Param: 'angular.toJson($scope.model)' }
        })
            .error(function (data, status, headers, config) {
                alert('error ' + status);
            })
            .success(function (data, status, headers, config) {
                $scope.data = data; //angular.fromJson(data);
                $scope.PrepareData();
            })
        ;//end-of-$http.get
    }
}//end-of-StandardComboController

