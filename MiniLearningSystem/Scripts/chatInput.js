$(function () {
    var chat = $.connection.chatHub;

    chat.client.recieveMessage = function (name, message) {
        var resStr = '';
        var senderName = $('#sender-name').html();
        debugger;

        var position = '';
        var pic = '';

        var patt = '<li class="$position clearfix">'+
                      '<span class="chat-img pull-$position">'+
                          '<img src="$pic" alt="User Avatar" class="img-circle" />'+
                      '</span>'+
                      '<div class="chat-body clearfix">'+
                        '<div class="header">'+
                            '<strong class="primary-font">$name</strong>'+
                        '</div>'+
                        '<p>$message</p>'+
                      '</div>'+
                   '</li >';



        if (name === senderName) {
            
            position = 'left';
            pic = 'http://placehold.it/50/55C1E7/fff&text=U';
            
            //resStr = '<li class="right clearfix"><span class="chat-img pull-right" >' +
            //    '<img src="http://placehold.it/50/FA6F57/fff&text=ME" alt="User Avatar" class="img-circle" />';

        } else {
            position = 'right';
            pic = 'http://placehold.it/50/FA6F57/fff&text=ME';

            //resStr = '<li class="left clearfix"><span class="chat-img pull-left" >' +
            //    '<img src="http://placehold.it/50/55C1E7/fff&text=U" alt="User Avatar" class="img-circle" />';
        }

        resStr = patt.replace('$position', position).replace('$name', name).replace('$message', message).replace('$pic', pic);

        //resStr = resStr +
        //    '</span>' +
        //    '<div class="chat-body clearfix">' +
        //    '<div class="header">';
        //resStr += name;
        //resStr += '</div><p>' + message + '</p></div></li >';

        $('#message').val('');

        $('#conversation').append(resStr);
    };
});
