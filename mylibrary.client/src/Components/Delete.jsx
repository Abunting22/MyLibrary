import React, { useState } from 'react';
import { Button, Modal } from 'react-bootstrap';
import '../Styles/Delete.css';

function Delete({ data }) {
    const [show, setShow] = useState(false);

    const [bookData, setBookData] = useState(data);

    const handleClose = () => { setShow(false); console.log('Show:', show); };
    const handleShow = () => { setShow(true); console.log('Show:', show); };

    const handleDelete = async () => {
        console.log(JSON.stringify(bookData));
        try {
            const response = await fetch(`https://localhost:7284/api/books/Delete/${bookData.bookId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });
            if (!response.ok) {
                throw new Error('Network response invalid');
            }
            console.log("Book deleted");

            handleClose();
        } catch (error) {
            console.error('Error deleting data:', error)
        }
    }
    return (
        <div>
            <Button variant='danger' onClick={handleShow}>
                Delete
            </Button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Confirm Deletion</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Are you sure you want to delete this book?
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cancel
                    </Button>
                    <Button variant="danger" onClick={handleDelete}>
                        Delete
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}

export default Delete;