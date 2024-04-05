import { useEffect, useState } from 'react';
import Book from '../Components/Book';
import FetchData from '../Components/FetchData';
import Header from '../Components/Header.jsx';
import '../Styles/Fiction.css';
import SortData from '../Components/SortData';

function Fiction({ sortBy }) {
    const [data, setData] = useState();
    //let type = 1;
    //const bookData = FetchData({ type });
    //const sortedBookData = SortData({ data, sortBy });

    //useEffect(() => {
    //    if (sortBy === '') {
    //        setData(bookData);
    //    }
    //    else {
    //        setData(sortedBookData);
    //    }
    //}, [sortBy]);

    return (
        <div className='fiction-page'>
            <div className='header'><Header /></div>
            <div className='book-data'>
                {data && data.map((item, index) => (
                    <Book key={index} data={item} />
                ))}
            </div>
        </div>
    );
}

export default Fiction;