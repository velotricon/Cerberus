function ListDirective() {
    return {
        //template: '<div ng-transclude class="list"></div>',
        templateUrl: 'Template/List',
        restrict: 'E',
        transclude: true,
        scope: true,
        link: ListDirectiveLinkFunction,
        controller: ListDirectiveController
    }
}

function ListDirectiveLinkFunction (scope, element, attrs, ctrl, transcludeFn) {

}//end-of-ListDirectiveLinkFunction

function ListDirectiveController($scope, $element, $attrs, $transclude, $filter) {
    var v_element = $element;
    var filter_name = 'JsonDateFilter';
    $scope.x = 'a2';
    $scope.smiesznypiesek = "/Date(1430763733270)/";
    $scope.smiesznypiesek2 = $filter(filter_name)($scope.smiesznypiesek);
    $scope.ListItems = new Array();
    $scope.ListItems.push('serdelek');
    $scope.RegisterListItem = function (Text) {
        $scope.ListItems.push(Text);
    }
}//end-of-ListDirectiveController
