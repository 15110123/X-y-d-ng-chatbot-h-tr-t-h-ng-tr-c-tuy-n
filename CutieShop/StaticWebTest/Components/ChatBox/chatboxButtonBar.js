var emojiTableToggle = () => {
    $('#EmojiTable').toggle();
};

var addEmojiToTextBox = () => {
    //Add code to add emoji to textbox here
    console.log('here');
};

var uploadImg = (msgId, file, destUrl) =>{
var formData = new FormData();
formData.append('msgId', msgId);
if (file)
{
    formData.append('img', file);
}
var request = new XMLHttpRequest();
request.open('POST', destUrl);
request.send(formData);
};

var previewFile = () => {
    var preview = $('#UploadedImage-id12345')[0];
    var file    = $('#BtnFileUpload')[0].files[0];
    var reader  = new FileReader();

    reader.onloadend = (o) => {
        preview.src = o.srcElement.result;
    }
    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
};

$('.EmojiIcon').on('click', emojiTableToggle);

$('.Emoji').on('click', emojiTableToggle);
$('.Emoji').on('click', addEmojiToTextBox);

$('#BtnFileUpload').on('change', previewFile);