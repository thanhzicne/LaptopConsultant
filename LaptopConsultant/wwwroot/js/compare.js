document.querySelectorAll('.compare-btn').forEach(button => {
    button.addEventListener('click', function (e) {
        e.preventDefault(); // Ngăn hành vi mặc định của form (nếu cần)
        const laptopId = this.getAttribute('data-laptop-id');
        fetch('/Laptop/AddToCompare', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: `laptopId=${laptopId}`
        }).then(response => {
            if (response.ok) {
                window.location.href = '/Laptop/Compare';
            } else {
                alert('Không thể thêm laptop vào danh sách so sánh.');
            }
        });
    });
});