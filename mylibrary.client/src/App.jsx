import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Start from './Pages/Start.jsx';
import Fiction from './Pages/Fiction.jsx';
import Nonfiction from './Pages/Nonfiction.jsx';
import Add from './Pages/Add.jsx';
import Update from './Pages/Update.jsx';
import Delete from './Pages/Delete.jsx';

function App() {
    return (
        <div>
            <Router>
                <Routes>
                    <Route path='/' element={<Start />} />
                    <Route path='/fiction' element={<Fiction />} />
                    <Route path='/nonfiction' element={<Nonfiction />} />
                    <Route path='/add' element={<Add/> } />
                    <Route path='/update' element={<Update/> } />
                    <Route path='/delete' element={<Delete/> } />
                </Routes>
            </Router>
        </div>
    )
}

export default App;