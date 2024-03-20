import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, ButtonGroup } from 'react-bootstrap';
import '../Styles/Book.css';

const Book = ({ data }) => {
    const history = useNavigate();

    const handleNavigation = (route) => {
        history(route);
    }

    return (
        <div className='book'>
            <div className='book-title'><h2>{data.title}</h2></div>
            <div className='book-author'><p>{data.author}</p></div>
            <div className='book-publication'><p>{data.publication}</p></div>
            <div className='book-edition'><p>{data.edition}</p></div>
            <div className='book-genre'><p>{data.genre}</p></div>
            <ButtonGroup className='book-btn-group'>
                <Button className='update-btn' onClick={() => handleNavigation('/update')}>
                    Edit
                </Button>
                <Button className='delete-btn' onClick={() => handleNavigation('/delete')}>
                    Delete
                </Button>
            </ButtonGroup>
        </div>
    )
}

export default Book;