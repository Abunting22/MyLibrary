import { useEffect, useState } from 'react';
import FetchData from './FetchData';

function SortData({ bookData, sortBy }) {
    const [sortedBookData, setSortedBookData] = useState();

    useEffect(() => {
        const sortingTypes = () => {
            title: (a, b) => a.title.localeComparer(b.title);
            author: (a, b) => a.author.localeComparer(b.author);
            genre: (a, b) => a.genre.localeComparer(b.genre);
            publicationYear: (a, b) => a.publicationYear.localeComparer(b.publicationYear);
        };

        const sortBooks = sortingTypes[sortBy];
        if (!sortBooks) return;

        const sortData = () => {
            try {
                const sortedData = bookData.sort(sortBooks);
                setSortedBookData(sortedData);
            } catch (error) {
                console.error('Error sorting data:', error);
            }
        };

        sortData();
    }, [bookData, sortBy]);

    return sortedBookData;
}

export default SortData;

