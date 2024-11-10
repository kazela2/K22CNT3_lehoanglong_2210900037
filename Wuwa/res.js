function showContent(index) {
    // Ẩn tất cả nội dung
    const contents = document.querySelectorAll('.content');
    contents.forEach(content => content.style.display = 'none');

    // Hiển thị box và nội dung được chọn
    document.getElementById('contentBox').style.display = 'block';
    document.getElementById(`content${index}`).style.display = 'block';
}
