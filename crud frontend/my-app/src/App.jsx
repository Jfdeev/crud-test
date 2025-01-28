import React from 'react';
import ProdutoList from './components/ProductList.jsx';
import ProdutoForm from './components/ProductForm.jsx';
import Dashboard from './components/Dashboard.jsx';

const App = () => {
    return (
        <div>
            <Dashboard />
            <ProdutoForm />
            <ProdutoList />
        </div>
    );
};

export default App;