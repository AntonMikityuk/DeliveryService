import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import OrderList from './components/OrderList';
import OrderForm from './components/OrderForm';
import OrderDetails from './components/OrderDetails';
import './App.css';

function App() {
    return (
        <Router>
            <div className="app-container">
                <nav className="navbar">
                    <div className="nav-logo">DeliveryService</div>
                    <div className="nav-links">
                        <Link to="/">Список заказов</Link>
                        <Link to="/create" className="btn-primary">Новый заказ</Link>
                    </div>
                </nav>

                <main className="content">
                    <Routes>
                        <Route path="/" element={<OrderList />} />
                        <Route path="/create" element={<OrderForm />} />
                        <Route path="/order/:id" element={<OrderDetails />} />
                        <Route path="/edit/:id" element={<OrderForm />} />
                    </Routes>
                </main>
            </div>
        </Router>
    );
}

export default App;