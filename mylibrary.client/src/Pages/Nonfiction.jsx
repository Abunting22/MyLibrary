import React from 'react';
import Book from '../Components/Book';
import FetchData from '../Components/FetchData';
import Header from '../Components/Header.jsx';
import '../Styles/Nonfiction.css';

function Nonfiction() {
    const bookData = FetchData(0);
    return (
        <div className='nonfiction-page'>
            <div className='header'><Header /></div>
            <div className='book-data'>
                {bookData && bookData.map((item, index) => (
                    <Book key={index} data={item} />
                ))}
            </div>
        </div>
    )
}

export default Nonfiction;