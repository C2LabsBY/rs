$(document).ready(function(){
    $("table tr:odd").addClass("odd");
    $("table tr:not(.odd)").addClass("even");
    $("table tr td:first-child").addClass("first");
    $("table tr td:last-child").addClass("last");

    // set .pro-detail-tab-sidebar and .pro-detail-tab-data to be equal height
    var proDetailTabSidebar = $('.pro-detail-tab-sidebar'),
        proDetailTabData = $('.pro-detail-tab-data');
    if ($(proDetailTabSidebar).length >= 1 && $(proDetailTabData).length >= 1) {
        var maxHeight = $(proDetailTabSidebar).height() > $(proDetailTabData).height() ? $(proDetailTabSidebar).height() : $(proDetailTabData).height();
        $(proDetailTabSidebar).height(maxHeight);
        $(proDetailTabData).height(maxHeight)
    }    
});

function agentClick(aid, acid) {
    $('.agent-mobile' + aid).hide();
    $('.agent-mobile-full' + aid).show();

    $.ajax({
        url: "LogMobilePhoneClick.ashx",
        contentType: "application/json; charset=utf-8",
        data: { 'aID': aid, 'acID': acid },
        success: function (msg) { return false; }
    });

    return false;
}

function getSlideData(number, slide) {
    //attribute index of an <a> tag
    var index = number - 1;
    //get current advertisement
    var el = slide + ' a.slidesjs-slide[slidesjs-index=' + index + '] img';
    var currentAdv = $(el);
    //banner don't have a link thus banner object is not found
    if (currentAdv.length == 0) {
        el = slide + ' div.slidesjs-slide[slidesjs-index=' + index + '] img';
        currentAdv = $(el);
    }
    //advertisement id
    var advId = currentAdv.data('advId');
    //flag displaying if view of the banner is saved
    var isSaved = currentAdv.data('isSaved');
    //if view is not saved we save the view in db
    if (isSaved == 0) {
        console.log('Current index of ' + slide + ' is ' + index + ' and AdId is ' + advId);
        currentAdv.data('isSaved', '1').attr('data-is-saved', '1');
        AddAdvertisementView(advId);
    }
}

//get simple image data 
function getImageData(slide) {
    //get current advertisement
    var el = slide + " img";
    var currentAdv = $(el);
    //advertisement id
    var advId = currentAdv.data('advId');
    //flag displaying if view of the banner is saved
    var isSaved = currentAdv.data('isSaved');
    //if view is not saved we save the view in db
    if (isSaved == 0) {
        console.log('Current AdId of ' + slide + ' is ' + advId);
        currentAdv.data('isSaved', '1').attr('data-is-saved', '1');
        AddAdvertisementView(advId);
    }
}

function AddAdvertisementView(adid) {
    $.ajax({
        url: "AddAdvertisementView.ashx",
        contentType: "application/json; charset=utf-8",
        data: { 'AdId': adid },
        success: function (msg) { return false; }
    });
}

//send email from contact form
function sendEmail(txtName, txtPhone, txtEmail, txtComments, txtCode, sendToEmail, currentPageName) {
    var res = false;
    $.ajax({
        url: "/SendEmailFromContactForm.ashx",
        contentType: "application/json; charset=utf-8",
        async: false,
        data: {
            'txtName': txtName,
            'txtPhone': txtPhone,
            'txtEmail': txtEmail,
            'txtComments': txtComments,
            'txtCode': txtCode,
            'currentPageName': currentPageName,
            'sendToEmail': sendToEmail
        },
        success: function (msg) {
            if (msg == 'true') {
                res = true;
            }
            else if (msg == 'captchaFail') {
                alert('The code entered did not match the image, please try again.');
            }
            else {
                alert(msg);
            }
        }
    });

    return res;
}

//send email from contact agency form
function sendEmailToAgency(txtName, txtPhone, txtEmail, txtComments, txtCode, agencyName, sendToEmail) {
    var res = false;
    $.ajax({
        url: "/SendEmailFromContactAgencyForm.ashx",
        contentType: "application/json; charset=utf-8",
        async: false,
        data: {
            'txtName': txtName,
            'txtPhone': txtPhone,
            'txtEmail': txtEmail,
            'txtComments': txtComments,
            'txtCode': txtCode,
            'agencyName': agencyName,
            'sendToEmail': sendToEmail
        },
        success: function (msg) {
            if (msg == 'true') {
                res = true;
            }
            else if (msg == 'captchaFail') {
                alert('The code entered did not match the image, please try again.');
            }
            else {
                alert(msg);
            }
        }
    });

    return res;
}

//send email from enquire form
function sendEnquire(txtName, txtPhone, txtEmail, txtComments, txtCode, currentPageName, replyBy, toKnow, propertyId, link) {
    var res = false;
    $.ajax({
        url: "/SendEmailFromEnquireForm.ashx",
        contentType: "application/json; charset=utf-8",
        async: false,
        data: {
            'txtName': txtName,
            'txtPhone': txtPhone,
            'txtEmail': txtEmail,
            'txtComments': txtComments,
            'txtCode': txtCode,
            'currentPageName': currentPageName,
            'replyBy': replyBy,
            'toKnow': toKnow,
            'propertyId': propertyId,
            'link': link
        },
        success: function (msg) {
            if (msg == 'true') {
                res = true;
            }
            else if (msg == 'captchaFail') {
                alert('The code entered did not match the image, please try again.');
            }
            else {
                alert(msg);
            }
        }
    });

    return res;
}