import { useEffect, useState } from 'react';
import '../Styles/FetchData.css';

function FetchData({type}) {
    const [bookData, setBookData] = useState();

    useEffect(() => {
        const fetchData = async () => {

            let url;
            if (type === 1) 
                url = 'https://localhost:7284/api/books/GetAllFiction'
            else
                url = 'https://localhost:7284/api/books/GetAllNonfiction'

            try {
                const response = await fetch(url, {
                    method: 'GET',
                    headers: {
                        accept: 'application/json'
                    }
                });
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const data = await response.json();
                setBookData(data);
                console.log(data);

            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [type]);

    return bookData;
}
export default FetchData;