import React, { useState } from 'react';
import { Dropdown, DropdownButton } from 'react-bootstrap';
import Fiction from '../Pages/Fiction';

function Sort() {
    const [sortBy, setSortBy] = useState();

    const handleSortChange = (sortType) => {
        setSortBy(sortType);
    }

    return (
        <>
            <DropdownButton id="sort-button" title="Sort">
                <Dropdown.Item href="#/sort-title" onClick={() => handleSortChange('title')}>Title</Dropdown.Item>
                <Dropdown.Item href="#/sort-author" onClick={() => handleSortChange('author')}>Author</Dropdown.Item>
                <Dropdown.Item href="#/sort-published" onClick={() => handleSortChange('publicationYear')}>Published</Dropdown.Item>
                <Dropdown.Item href="#/sort-genre" onClick={() => handleSortChange('genre')}>Genre</Dropdown.Item>
            </DropdownButton>
         </>
    );
}

export default Sort;