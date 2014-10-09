<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideBarRefineResults.ascx.cs" Inherits="usercontrols_SideBarRefineResults" %>
<section class="sidebar-form sidebar-form2 clearfix">
    <h2>REFINE SEARCH</h2>
    <ul class="form-view refine-search-form">
    <li>
        <label for="poperty-type">PROPERTY TYPE:</label>
        <select name="poperty-type" id="poperty-type">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        </select>
    </li>
    <li>
        <label for="bedrooms">MIN. BEDROOMS:</label>
        <select name="bedrooms" id="bedrooms">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        </select>
    </li>
    <li>
        <label for="bathrooms">MIN BATHROOMS:</label>
        <select name="bathrooms" id="bathrooms">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        </select>
    </li>
    <li>
        <label for="min-price">MIN PRICE:</label>
        <select name="min-price" id="min-price">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        </select>
    </li>
    <li>
        <label for="max-price">MAX PRICE:</label>
        <select name="max-price" id="max-price">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        </select>
    </li>
    <li class="no-label">
        <input type="submit" value="Search" class="red-btn" />
    </li>
    </ul>
</section>