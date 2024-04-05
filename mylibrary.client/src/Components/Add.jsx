import React, { useState } from 'react';
import { Form, Button, Modal } from 'react-bootstrap';
import '../Styles/Add.css';

function Add() {
    const [bookData, setBookData] = useState({
        category: '',
        title: '',
        author: '',
        publicationYear: '',
        genre: '',
        edition: ''
    });

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleChange = (e) => {
        setBookData({
            ...bookData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log(JSON.stringify(bookData));
        try {
            const response = await fetch('https://localhost:7284/api/books/Add',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(bookData)
            });
            if (!response.ok) {
                throw new Error('Network response invalid');
            }

            const data = await response.json();
            console.log(data);
            handleClose();
        } catch (error) {
            console.error('Error posting data:', error)
        }
    };

    return (
        <div>
            <Button variant='primary' onClick={handleShow}>
                Add
            </Button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group controlId="category">
                            <Form.Control as="select" name="category" value={bookData.category} onChange={handleChange}>
                                <option value="1">Fiction</option>
                                <option value="2">Nonfiction</option>
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="title">
                            <Form.Control type="text" name="title" placeholder="Title" value={bookData.title} onChange={handleChange} />
                        </Form.Group>
                        <Form.Group controlId="author">
                            <Form.Control type="text" name="author" placeholder="Author" value={bookData.author} onChange={handleChange} />
                        </Form.Group>
                        <Form.Group controlId="publicationYear">
                            <Form.Control type="text" name="publicationYear" placeholder="Publication Year" value={bookData.publicationYear} onChange={handleChange} />
                        </Form.Group>
                        <Form.Group controlId="genre">
                            <Form.Control type="text" name="genre" placeholder="Genre" value={bookData.genre} onChange={handleChange} />
                        </Form.Group>
                        <Form.Group controlId="edition">
                            <Form.Control type="text" name="edition" placeholder="Edition" value={bookData.edition} onChange={handleChange} />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="primary" onClick={handleSubmit}>
                        Add
                    </Button>
                </Modal.Footer>
            </Modal>

        </div>
    )
}

export default Add;