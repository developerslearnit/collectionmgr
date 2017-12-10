/**
 * Module for perform some javascript tasks" 
 *
 * @author Mark Adesina <omark@simplexsystem.com>
 */

var SiteUtils = SiteUtils || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog='';
    //var $dialog = $('<div id="ibsLoading" style="display:block" class="loadmodal">' +
    //    '<div class="modalInner">' +
    //    '<div id="loadingMessage" class="cssload-loader">' +
    //    '<img src="/Content/img/loading.gif" alt=""><p>Loading</p></div>' +
    //    '</div></div>');

    function dialogContent(msg) {
        $dialog = $('<div id="ibsLoading" style="display:block" class="loadmodal">' +
        '<div class="modalInner">' +
        '<div id="loadingMessage" class="cssload-loader">' +
        '<p><img src="/content/assets/images/loading.gif"></img>' + msg + '</p></div>' +
        '</div></div>');

        return $dialog;
    }

    


    var utilsFunc = {

        //Format Number
        formatNumber: function (num) {
            if (num == undefined) {
                return 0;
            }

            return accounting.formatMoney(num, '');

        },
        removeFormat: function (num) {
            return accounting.unformat(num);
        },

        toFixed: function (num) {
            return accounting.toFixed(num);
        },
        loading: function (message) { //Show Loading Icon
            if (typeof message === 'undefined') {
                message = 'Loading....';
            }

            dialogContent(message).appendTo('body');
        },
        loadingOff: function () {
            $('body').find($("#ibsLoading")).remove();
        },
         createGuid: function () {
            return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
        }
    }


    return utilsFunc;



})(jQuery);