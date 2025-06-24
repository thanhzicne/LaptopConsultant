document.addEventListener('DOMContentLoaded', () => {
    const budgetRange = document.getElementById('budgetRange');
    const budgetValue = document.getElementById('budgetValue');

    budgetRange.addEventListener('input', () => {
        let value = budgetRange.value;
        budgetValue.textContent = value >= 30 ? '30+ triệu VNĐ' : `${value} triệu VNĐ`;
    });
});