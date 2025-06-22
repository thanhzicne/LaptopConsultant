document.addEventListener('DOMContentLoaded', function () {
    const budgetRange = document.getElementById('budgetRange');
    const budgetValue = document.getElementById('budgetValue');
    if (budgetRange && budgetValue) {
        budgetRange.addEventListener('input', () => {
            budgetValue.textContent = `${budgetRange.value} triệu VNĐ`;
        });
    }
});