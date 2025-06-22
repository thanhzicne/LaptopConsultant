document.addEventListener('DOMContentLoaded', function () {
    const compareButtons = document.querySelectorAll('.compare-btn');
    const compareList = [];
    compareButtons.forEach(button => {
        button.addEventListener('click', () => {
            const laptopId = button.dataset.laptopId;
            if (compareList.length < 3 && !compareList.includes(laptopId)) {
                compareList.push(laptopId);
                if (compareList.length >= 2) {
                    window.location.href = `/Laptop/Compare?laptopIds=${compareList.join('&laptopIds=')}`;
                }
            } else if (compareList.includes(laptopId)) {
                alert('Laptop này đã được thêm vào so sánh!');
            } else {
                alert('Bạn chỉ có thể so sánh tối đa 3 laptop!');
            }
        });
    });
});