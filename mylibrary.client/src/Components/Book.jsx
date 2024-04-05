import React, { useEffect, useState } from 'react';
import { ButtonGroup } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
import '../Styles/Book.css';
import Delete from './Delete.jsx';
import Update from './Update.jsx';

const Book = ({ data }) => {
    const [bookData, setBookData] = useState(data);
    const location = useLocation();

    useEffect(() => {
        if (location.state && location.state.bookData) {
            setBookData(location.state.bookData);
            console.log(JSON.stringify(bookData))
        }
    }, [location.state]);

    return (
        <div className='book'>
            <div className='book-title'><h2>{bookData.title}</h2></div>
            <div className='book-author'><p>{bookData.author}</p></div>
            <div className='book-publicationYear'><p>{bookData.publicationYear}</p></div>
            <div className='book-genre'><p>{bookData.genre}</p></div>
            <div className='book-edition'><p>{bookData.edition}</p></div>
            
            <ButtonGroup className='book-btn-group'>
                <Update data={bookData} />
                <Delete data={bookData} />
            </ButtonGroup>
        </div>
    )
}

export default Book;
