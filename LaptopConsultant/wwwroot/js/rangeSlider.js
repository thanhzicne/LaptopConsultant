
document.addEventListener('DOMContentLoaded', () => {
    const budgetRange = document.getElementById('budgetRange');
    const budgetValue = document.getElementById('budgetValue');
    const budgetInput = document.createElement('input');
    
    if (!budgetRange || !budgetValue) {
        console.error('Không tìm thấy budgetRange hoặc budgetValue');
        return;
    }

    // Tạo input ẩn để gửi giá trị Budget
    budgetInput.type = 'hidden';
    budgetInput.name = 'Budget';
    budgetRange.parentElement.appendChild(budgetInput);

    budgetRange.addEventListener('input', () => {
        const value = budgetRange.value;
        budgetValue.textContent = value >= 70 ? '70+ triệu VNĐ' : `${ value } triệu VNĐ`;
        budgetInput.value = value; // Cập nhật giá trị gửi về server
    });

    // Khởi tạo giá trị ban đầu
    budgetValue.textContent = budgetRange.value >= 70 ? '70+ triệu VNĐ' : `${ budgetRange.value } triệu VNĐ`;
    budgetInput.value = budgetRange.value;
});
