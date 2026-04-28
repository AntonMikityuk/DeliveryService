import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api';

const OrderList = () => {
    const [orders, setOrders] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        api.get('/Orders').then(res => setOrders(res.data)).catch(console.error);
    }, []);

    return (
        <div className="fade-in">
            <h1>Все заказы</h1>
            <div className="orders-grid">
                {orders.map(order => (
                    <div key={order.id} className="order-card" onClick={() => navigate(`/order/${order.id}`)}>
                        <div className="order-card-header" style={{ display: 'flex', justifyContent: 'space-between', marginBottom: '15px' }}>
                            <span className="order-num" style={{ fontWeight: 'bold', color: '#68217a' }}>{order.orderNumber}</span>
                            <span className="order-date" style={{ color: '#666' }}>{new Date(order.pickupDate).toLocaleDateString()}</span>
                        </div>

                        <div className="order-card-route" style={{ fontSize: '1.1rem', marginBottom: '10px' }}>
                            <p style={{ margin: '5px 0' }}><strong>Откуда:</strong> {order.senderCity}</p>
                            <p style={{ margin: '5px 0' }}><strong>Куда:</strong> {order.receiverCity}</p>
                        </div>

                        <div className="order-card-footer" style={{ marginTop: '15px', paddingTop: '10px', borderTop: '1px solid #eee', color: '#444' }}>
                            <span>Вес: <strong>{order.weight} кг</strong></span>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default OrderList;