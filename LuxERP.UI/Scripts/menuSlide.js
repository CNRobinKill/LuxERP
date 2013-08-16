/// <reference path="jquery-1.9.1-vsdoc.js" />
function menuSlide(topID, curID) {
    $(topID).addClass('nav-top-item current');
    $(curID).addClass('current');
    $('.nav-top-item.current').parent().find('ul').slideToggle();
};
function menuSlideTop(topID) {
    $(topID).addClass('nav-top-item current');
};