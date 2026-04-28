import { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import api from '../api';

const OrderForm = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const isEditMode = Boolean(id);

    const [formData, setFormData] = useState({
        senderCity: '', senderAddress: '',
        receiverCity: '', receiverAddress: '',
        weight: '', pickupDate: ''
    });

    
    useEffect(() => {
        if (isEditMode) {
            api.get(`/Orders/${id}`)
                .then(res => {
                    const formattedDate = res.data.pickupDate.split('T')[0];
                    setFormData({ ...res.data, pickupDate: formattedDate });
                })
                .catch(() => alert("Ошибка при загрузке данных заказа"));
        }
    }, [id, isEditMode]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const payload = { ...formData, weight: parseFloat(formData.weight) };

            if (isEditMode) {
                await api.put(`/Orders/${id}`, payload);
                alert('Заказ обновлен!');
            } else {
                await api.post('/Orders', payload);
                alert('Заказ создан!');
            }
            navigate('/');
        } catch {
            alert('Ошибка при сохранении. Проверьте данные.');
        }
    };

    return (
        <div className="form-container">
            <h2 style={{ color: 'var(--vs-purple)' }}>{isEditMode ? 'Редактирование' : 'Новая заявка'}</h2>
            <form onSubmit={handleSubmit} className="styled-form">
                <div className="form-row">
                    <div className="form-section">
                        <h3>Отправитель</h3>
                        <input placeholder="Город" value={formData.senderCity} required
                            onChange={e => setFormData({ ...formData, senderCity: e.target.value })} />
                        <input placeholder="Адрес" value={formData.senderAddress} required
                            onChange={e => setFormData({ ...formData, senderAddress: e.target.value })} />
                    </div>
                    <div className="form-section">
                        <h3>Получатель</h3>
                        <input placeholder="Город" value={formData.receiverCity} required
                            onChange={e => setFormData({ ...formData, receiverCity: e.target.value })} />
                        <input placeholder="Адрес" value={formData.receiverAddress} required
                            onChange={e => setFormData({ ...formData, receiverAddress: e.target.value })} />
                    </div>
                </div>

                <div className="form-row">
                    <div className="form-section">
                        <h3>Груз и дата</h3>
                        <div style={{ display: 'flex', gap: '15px' }}>
                            <input type="number" step="0.1" placeholder="Вес (кг)" value={formData.weight} required
                                onChange={e => setFormData({ ...formData, weight: e.target.value })} />
                            <input type="date" value={formData.pickupDate} required
                                onChange={e => setFormData({ ...formData, pickupDate: e.target.value })} />
                        </div>
                    </div>
                </div>

                <button type="submit" className="submit-btn-large">
                    {isEditMode ? 'СОХРАНИТЬ ИЗМЕНЕНИЯ' : 'СОЗДАТЬ ЗАКАЗ'}
                </button>
            </form>
        </div>
    );
};

export default OrderForm;