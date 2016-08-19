function TextFieldDirective() {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            regex: '@',
            validation: '=',//funkcja walidacyjna bierze string zwraca bool
            model: '=',
            errortext: '@'
        },//end-of-scope
        link: TextFieldLinkFunction,
        controller: TextFieldController
    }//end-of-return
}//end-of-TextFieldDIrective


function TextFieldLinkFunction(scope, element, attr, ctrl, transcludeFn) {

}

function TextFieldController($scope, $element, $attrs, $transclude) {

}