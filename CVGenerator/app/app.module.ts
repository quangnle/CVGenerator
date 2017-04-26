/// <reference path="references.ts" />
'use strict';
((): void => {
    var cvGeneratorApp = angular.module("cvGeneratorApp", ['uiCropper']);

    cvGeneratorApp.factory('httpInterceptor', ['logger', _ => httpInterceptor(_)]);
    cvGeneratorApp.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('httpInterceptor');
    }]);

    function httpInterceptor(logger) {
        return {
            request: function (config) {
                //config.headers['Authorization'] = "Bearer " + CVGen.Base.UserToken;
                config.headers.Authorization = CVGen.Base.Const.USER_TOKEN;        
                return config;
            },

            response: function (res) {
                if (res.status != 200) {
                    logger.logWarning("ERROR CODE " + res.status);
                }
                return res;
            },

            responseError: function (res) {
                switch (res.status) {
                    default:
                        debugger;
                        logger.logError("# RESPONSE ERROR STATUS CODE " + res.status);
                        break;
                }
                return res;
            }
        }
    }

    cvGeneratorApp.config(function ($locationProvider) {
        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
        //$locationProvider.hashPrefix("");
    });

    cvGeneratorApp.service("profileService", CVGen.Services.ProfileService);
    cvGeneratorApp.service("skillService", CVGen.Services.SkillService);
    cvGeneratorApp.service("templateService", CVGen.Services.TemplateService);
    cvGeneratorApp.service("workExpService", CVGen.Services.WorkExpService);
    cvGeneratorApp.service("referenceService", CVGen.Services.ReferenceService);

    CVGen.Controller.Home.Configure(cvGeneratorApp);
    CVGen.Controller.Resume.Configure(cvGeneratorApp);
    CVGen.Controller.Profile.Configure(cvGeneratorApp);
    CVGen.Controller.UserResume.Configure(cvGeneratorApp);
    CVGen.Controller.Common.Configure(cvGeneratorApp);

    cvGeneratorApp.config(() => {
        if (CVGen.Base.Const.USER_TOKEN == null || CVGen.Base.Const.USER_TOKEN == '') {
            CVGen.Base.Const.USER_TOKEN = localStorage.getItem("tk");
        } else {
            localStorage.setItem("tk", CVGen.Base.Const.USER_TOKEN);
        }
    });

    cvGeneratorApp.factory("logger", [
        function () {
            var logIt;
            return toastr.options = {
                closeButton: !0,
                positionClass: "toast-bottom-right",
                timeOut: 3000
            }, logIt = function (message, type) {
                return toastr[type](message);
            }, {
                    log: function (message) {
                        logIt(message, "info");
                    },
                    logWarning: function (message) {
                        logIt(message, "warning");
                    },
                    logSuccess: function (message) {
                        logIt(message, "success");
                    },
                    logError: function (message) {
                        logIt(message, "error");
                    }
                }
        }
    ]);

    cvGeneratorApp.directive('sgNumberInput', ['$filter', '$locale', function ($filter, $locale) {
        return {
            require: 'ngModel',
            restrict: "A",
            link: function ($scope, element, attrs: any, ctrl: any) {
                var fractionSize = parseInt(attrs['fractionSize']) || 0;
                var numberFilter = $filter('number');
                //format the view value
                ctrl.$formatters.push(function (modelValue) {
                    var retVal = numberFilter(modelValue, fractionSize);
                    var isValid = isNaN(modelValue) == false;
                    ctrl.$setValidity(attrs.name, isValid);
                    return retVal;
                });
                //parse user's input
                ctrl.$parsers.push(function (viewValue) {
                    var caretPosition = getCaretPosition(element[0]), nonNumericCount = countNonNumericChars(viewValue);
                    viewValue = viewValue || '';
                    //Replace all possible group separators
                    var trimmedValue = viewValue.trim().replace(/,/g, '').replace(/`/g, '').replace(/'/g, '').replace(/\u00a0/g, '').replace(/ /g, '');
                    //If numericValue contains more decimal places than is allowed by fractionSize, then numberFilter would round the value up
                    //Thus 123.109 would become 123.11
                    //We do not want that, therefore I strip the extra decimal numbers
                    var separator = $locale.NUMBER_FORMATS.DECIMAL_SEP;
                    var arr = trimmedValue.split(separator);
                    var decimalPlaces = arr[1];
                    if (decimalPlaces != null && decimalPlaces.length > fractionSize) {
                        //Trim extra decimal places
                        decimalPlaces = decimalPlaces.substring(0, fractionSize);
                        trimmedValue = arr[0] + separator + decimalPlaces;
                    }
                    var numericValue = parseFloat(trimmedValue);
                    var isEmpty = numericValue == null || viewValue.trim() === "";
                    var isRequired = attrs.required || false;
                    var isValid = true;
                    if (isEmpty && isRequired) {
                        isValid = false;
                    }
                    if (isEmpty == false && isNaN(numericValue)) {
                        isValid = false;
                    }
                    ctrl.$setValidity(attrs.name, isValid);
                    if (isNaN(numericValue) == false && isValid) {
                        var newViewValue = numberFilter(numericValue, fractionSize);
                        element.val(newViewValue);
                        var newNonNumbericCount = countNonNumericChars(newViewValue);
                        var diff = newNonNumbericCount - nonNumericCount;
                        var newCaretPosition = caretPosition + diff;
                        if (nonNumericCount == 0 && newCaretPosition > 0) {
                            if (fractionSize > 0) {
                                newCaretPosition--;
                            }
                        }
                        setCaretPosition(element[0], newCaretPosition);
                    }
                    return isNaN(numericValue) == false ? numericValue : null;
                });
            } //end of link function
        };
        //#region helper methods
        function getCaretPosition(inputField) {
            // Initialize
            var position = 0;
            // IE Support
            //if (document.selection) {
            //    inputField.focus();
            //    // To get cursor position, get empty selection range
            //    var emptySelection = document.selection.createRange();
            //    // Move selection start to 0 position
            //    emptySelection.moveStart('character', -inputField.value.length);
            //    // The caret position is selection length
            //    position = emptySelection.text.length;
            //}
            //else
            if (inputField.selectionStart || inputField.selectionStart == 0) {
                position = inputField.selectionStart;
            }
            return position;
        }
        function setCaretPosition(inputElement, position) {
            if (inputElement.createTextRange) {
                var range = inputElement.createTextRange();
                range.move('character', position);
                range.select();
            }
            else {
                if (inputElement.selectionStart) {
                    inputElement.focus();
                    inputElement.setSelectionRange(position, position);
                }
                else {
                    inputElement.focus();
                }
            }
        }
        function countNonNumericChars(value) {
            return (value.match(/[^a-z0-9]/gi) || []).length;
        }
        //#endregion helper methods
    }]);

    //valid-number
    cvGeneratorApp.directive('validNumber', function () {
        return {
            require: '?ngModel',
            link: function (scope, element, attrs, ngModelCtrl: any) {
                if (!ngModelCtrl) {
                    return;
                }

                ngModelCtrl.$parsers.push(function (val) {
                    if (angular.isUndefined(val)) {
                        var val: any = '';
                    }

                    var clean = val.replace(/[^-0-9\.\,]/g, '');
                    var negativeCheck = clean.split('-');
                    var decimalCheck = clean.split('.');
                    if (!angular.isUndefined(negativeCheck[1])) {
                        negativeCheck[1] = negativeCheck[1].slice(0, negativeCheck[1].length);
                        clean = negativeCheck[0] + '-' + negativeCheck[1];
                        if (negativeCheck[0].length > 0) {
                            clean = negativeCheck[0];
                        }

                    }

                    if (!angular.isUndefined(decimalCheck[1])) {
                        decimalCheck[1] = decimalCheck[1].slice(0, 2);
                        clean = decimalCheck[0] + '.' + decimalCheck[1];
                    }

                    if (val !== clean) {
                        ngModelCtrl.$setViewValue(clean);
                        ngModelCtrl.$render();
                    }
                    return clean;
                });

                element.bind('keypress', function (event) {
                    if (event.keyCode === 32) {
                        event.preventDefault();
                    }
                });
            }
        };
    });

})()