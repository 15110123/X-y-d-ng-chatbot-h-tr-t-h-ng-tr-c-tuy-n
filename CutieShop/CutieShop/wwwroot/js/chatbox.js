//$('#chatbox-form-input')[0].spellcheck = false;

    //Extend rows if necessary
    //$('#chatbox-form-input').on('input propertychange', () => {
    //    let newValue = parseInt($('#chatbox-form-input')[0].scrollHeight / 20);
    //    if (newValue <= 3) {
    //        $('#chatbox-form-input')[0].rows = newValue;
    //    }
    //});

    //Enter key up event
    //$('#chatbox-form-input').on('keyup', (o) => {
    //    if (o.originalEvent.code === 'Enter') {
    //        if (o.originalEvent.shiftKey != true) {
    //            $('#chatbox-form-input').val('')[0].rows = 1;
    //            //Send message
    //        }
    //    }
    //});

    //Hide/show chatbox-main when clicked
    $('#chatbox-footer').on('click', () => {
        $('#chatbox-container')[0].classList.toggle('hover-fx');
        $('#chatbox-main').toggle();
    });