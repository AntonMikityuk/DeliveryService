import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api';

const OrderDetails = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [order, setOrder] = useState(null);

    useEffect(() => {
        api.get(`/Orders/${id}`).then(res => setOrder(res.data)).catch(() => navigate('/'));
    }, [id, navigate]);

    const handleDelete = async () => {
        if (window.confirm("Удалить этот заказ навсегда?")) {
            try {
                await api.delete(`/Orders/${id}`);
                navigate('/');
            } catch {
                alert("Ошибка при удалении");
            }
        }
    };

    if (!order) return <p>Загрузка...</p>;

    return (
        <div className="details-container fade-in">
            <div className="details-header-row">
                <button onClick={() => navigate('/')} className="btn btn-outline">
                    Назад к списку
                </button>
                <div style={{ display: 'flex', gap: '12px' }}>
                    <button onClick={() => navigate(`/edit/${id}`)} className="btn btn-outline">
                        Редактировать
                    </button>
                    <button onClick={handleDelete} className="btn btn-danger">
                        Удалить заказ
                    </button>
                </div>
            </div>

            <div className="details-card">
                <h2>Информация о заказе {order.orderNumber}</h2>

                <div className="details-grid">
                    <div className="details-item">
                        <strong>Отправитель:</strong>
                        <span>{order.senderCity}, {order.senderAddress}</span>
                    </div>
                    <div className="details-item">
                        <strong>Получатель:</strong>
                        <span>{order.receiverCity}, {order.receiverAddress}</span>
                    </div>
                    <div className="details-item">
                        <strong>Вес груза:</strong>
                        <span>{order.weight} кг</span>
                    </div>
                    <div className="details-item">
                        <strong>Дата забора:</strong>
                        <span>{new Date(order.pickupDate).toLocaleDateString('ru-RU', {
                            day: 'numeric', month: 'long', year: 'numeric'
                        })}</span>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default OrderDetails;