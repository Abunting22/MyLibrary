import React from 'react';
import '../Styles/Book.css';

const Book = ({ data }) => {
    return (
        <div className='book'>
            <div className='book-title'><h2>{data.title}</h2></div>
            <div className='book-author'><p>{data.author}</p></div>
            <div className='book-publication'><p>{data.publication}</p></div>
            <div className='book-edition'><p>{data.edition}</p></div>
            <div className='book-genre'><p>{data.genre}</p></div>
        </div>
    )
}

export default Book;