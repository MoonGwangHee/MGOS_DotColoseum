<script>
    $(document).ready(function () {
    $('#commentForm').submit(function (event) {
        event.preventDefault();

        // 폼 데이터를 가져옵니다.
        var formData = {
            content: $('#content').val(),
            author: $('#author').val(),
            createdAt: $('#createdAt').val()
        };

        // 서버에 데이터를 전송합니다.
        $.ajax({
            type: 'POST',
            url: '/api/comments/addComment',
            contentType: 'application/json;charset=UTF-8',
            data: JSON.stringify(formData),
            success: function (data) {
                // 성공적으로 댓글이 추가된 경우 실행되는 코드
                console.log('댓글이 성공적으로 추가되었습니다.');
                loadComments();
            },
            error: function (error) {
                // 댓글 추가에 실패한 경우 실행되는 코드
                console.error('댓글 추가 중 오류가 발생했습니다.');
            }
        });
    });

    // 페이지 로딩 시 댓글 목록 불러오기
    loadComments();

    async function loadComments() {
    // 서버에서 댓글 목록 불러오기
    const response = await fetch('/api/comments');
    const comments = await response.json();

    // 댓글 목록을 HTML로 표시
    $('#comment-list').html('');
    comments.forEach((comment) => {
    const commentElement = document.createElement('li');
    commentElement.innerHTML = `
                <p><strong>${comment.author}</strong> - ${new Date(comment.createdAt).toLocaleDateString()}</p>
                <p>${comment.content}</p>
                <hr>
            `;
    $('#comment-list').append(commentElement);
});
}
});


</script>