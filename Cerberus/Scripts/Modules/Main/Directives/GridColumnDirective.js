function GridColumnDirective() {
    return {
        restrict: 'E',
        template: '',
        transclude: true,
        scope: {
            columnName: '@',
            dataType: '@',
            filter: '@'
        },
        require: '^grid',
        link: GridColumnDirectiveLinkFunction,
        controller: GridColumnController
    }//end-of-return
}//end-of-GridColumnDirective

function GridColumnDirectiveLinkFunction(scope, element, attr, ctrl, transcludeFn) {
    
}

function GridColumnController($scope, $element, $attrs, $transclude) {
    var info_obj = {};

    info_obj.ColumnName = $scope.ColumnName;
    info_obj.DataType = $scope.DataType;
    info_obj.Filter = $scope.Filter;
    $scope.$parent.SayHello();
    $scope.$parent.ColumnRegister(info_obj);
}

