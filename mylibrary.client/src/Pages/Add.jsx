import React, { useEffect, useState } from 'react';

function Add() {
    cosnt[bookData, setBookData] = useState({
        title: '',
        author: '',
        publication: '',
        edition: '',
        genre: ''
    });

    const [isFiction, setIsFiction] = useState(true);

    const handleChange = (e) => {
        setBookData({
            ...bookData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const apiUrl = isFiction ? 'https://localhost:7284/api/Fiction/AddNew' : 'https://localhost:7284/api/NonFiction/AddNew';
        try {
            const response = await fetch(apiUrl, {
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
        } catch (error) {
            console.error('Error posting data:', error)
        }
    };

    const toggleController = () => {
        setIsFiction((prevState) => !prevState);
    };

    return (
        <div>
            <button onClick={toggleController}>Toggle Controller</button>
            <form onSubmit={handleSubmit}>
                <input type="text" name="title" value={bookData.title} onChange={handleChange} />
                <input type="text" name="author" value={bookData.author} onChange={handleChange} /> 
                <input type="text" name="publication" value={bookData.pubication} onChange={handleChange} />
                <input type="text" name="edition" value={bookData.edition} onChange={handleChange} />
                <input type="text" name="genre" value={bookData.genre} onChange={handleChange} /> 
                <button type="submit">Submit</button>
            </form>
        </div>
    )
}

export default Add;