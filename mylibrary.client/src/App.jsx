import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Start from './Pages/Start.jsx';
import Fiction from './Pages/Fiction.jsx';
import Nonfiction from './Pages/Nonfiction.jsx';

function App() {
    return (
        <div>
            <Router>
                <Routes>
                    <Route path='/' element={<Start />} />
                    <Route path='/fiction' element={<Fiction />} />
                    <Route path='/nonfiction' element={<Nonfiction />} />
                </Routes>
            </Router>
        </div>
    )
}

export default App;