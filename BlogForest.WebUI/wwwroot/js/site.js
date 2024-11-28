// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var editor = CKEDITOR.instances['Description'];
    if (editor) {
        editor.destroy(true);
    }
    CKEDITOR.replace('Description', {
        enterMode: CKEDITOR.ENTER_BR,
        filebrowserUploadUrl: '/Writer/Blog/UploadCKEDITOR',
        fikebrowserBrowseUrl: '/Writer/Blog/FileBrowserCKEDITOR',
        toolbar =[
            { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print'] },
            { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'Undo', 'Redo'] },
            { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat'] },
            { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
            { name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'SpecialChar'] },
            { name: 'styles', items: ['Styles', 'Format'] },
            { name: 'tools', items: ['Maximize'] }
        ]
    });
});